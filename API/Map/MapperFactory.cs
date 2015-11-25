using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using AutoMapper.Internal;

namespace API.Map
{
    public static class MapperFactory
    {
        public static IMappingExpression<TSource, TDestination> Map<TSource, TDestination>()
        {
            return Mapper.CreateMap<TSource, TDestination>();
        }

        public static TDestination Create<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public static void Update<TSource, TDestination>(TSource source, TDestination entity)
        {
            Mapper.Map(source, entity);
        }

        public static IMappingExpression<TSource, TDestination> MapAllDomainBooleanToDbString<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);

            var pSources = sourceType.GetProperties().Where(p => p.PropertyType == typeof(bool));
            var pDests = destinationType.GetProperties().Where(p => p.PropertyType == typeof(string));

            pSources.Each(propertySource =>
            {
                var propertyDest = pDests.FirstOrDefault(pD => pD.Name == propertySource.Name);

                MethodInfo boolEqualsMethod = typeof(bool).GetMethod("Equals", new[] { typeof(bool) });

                if (propertyDest != null)
                {
                    var parameter = Expression.Parameter(sourceType, "p");
                    var propertyRef = Expression.Property(parameter, propertySource.Name);
                    var equalsTest = Expression.Call(propertyRef, boolEqualsMethod, Expression.Constant(true));

                    Expression trueReturn = Expression.Constant("S");
                    Expression falseReturn = Expression.Constant("N");
                    var ifExpression = Expression.Condition(equalsTest, trueReturn, falseReturn);

                    var lambda = Expression.Lambda<Func<TSource, string>>(ifExpression, new[] { parameter });

                    expression.ForMember(propertyDest.Name, opt => opt.MapFrom(lambda));
                }
            });

            return expression;
        }

        public static IMappingExpression<TSource, TDestination> MapAllDbStringToDomainBoolean<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);

            var pSources = sourceType.GetProperties().Where(p => p.PropertyType == typeof(string));
            var pDests = destinationType.GetProperties().Where(p => p.PropertyType == typeof(bool));

            pSources.Each(propertySource =>
            {
                var propertyDest = pDests.FirstOrDefault(pD => pD.Name == propertySource.Name);

                MethodInfo boolEqualsMethod = typeof(string).GetMethod("Equals", new[] { typeof(string) });

                if (propertyDest != null)
                {
                    var parameter = Expression.Parameter(sourceType, "p");
                    var propertyRef = Expression.Property(parameter, propertySource.Name);
                    var equalsTest = Expression.Call(propertyRef, boolEqualsMethod, Expression.Constant("S"));

                    Expression trueReturn = Expression.Constant(true);
                    Expression falseReturn = Expression.Constant(false);
                    var ifExpression = Expression.Condition(equalsTest, trueReturn, falseReturn);

                    var lambda = Expression.Lambda<Func<TSource, bool>>(ifExpression, new[] { parameter });

                    expression.ForMember(propertyDest.Name, opt => opt.MapFrom(lambda));
                }
            });

            return expression;
        }



        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);
            var existingMaps = Mapper.GetAllTypeMaps().First(x => x.SourceType.Equals(sourceType)
                && x.DestinationType.Equals(destinationType));
            foreach (var property in existingMaps.GetUnmappedPropertyNames())
            {
                expression.ForMember(property, opt => opt.Ignore());
            }
            return expression;
        }

        public static class DataBindingFactory
        {
            public static T Create<T>()
            {
                return Activator.CreateInstance<T>();
            }
        }
    }
}