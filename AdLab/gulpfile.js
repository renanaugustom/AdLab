var gulp = require('gulp');
var del = require('del');
var concat = require('gulp-concat');
var inject = require('gulp-inject');

var appSourcesAndCSS = [
    './app/app.js',
    './app/base/*.js',
    './app/services/*.js',
    './app/controllers/*.js',
    './app/directives/*.js',
    '!app/**/*.min.js',
    './content/**/*.css',
    '!./content/login.css',
];

var thirdPartySources = [
    './bower_components/jquery/jquery.min.js',
    './bower_components/angular/angular.min.js',
    './bower_components/angular-ui-router/release/angular-ui-router.min.js',
    './bower_components/a0-angular-storage/dist/angular-storage.min.js',
    './bower_components/bootstrap/dist/js/bootstrap.min.js',
    './bower_components/bootstrap/dist/css/bootstrap.min.css'
];

var debugInjectSrcs = [
    './dist/lib/angular.min.js',
    './dist/lib/jquery.min.js',
    './dist/lib/*.js',
    './dist/lib/*.css'
];

gulp.task('clean', function () {
    del.sync(['dist/**/*', 'dist/*'], { force: true })
});

gulp.task('thirdParty', ['clean'], function () {

    gulp.src(['./bower_components/bootstrap/dist/fonts/*'])
        .pipe(gulp.dest('./dist/fonts'));

    return gulp.src(thirdPartySources)
        .pipe(gulp.dest('./dist/lib'));
});

gulp.task('debugIndex', ['thirdParty'], function () {
    var target = gulp.src('./index.html');

    var appSources = gulp.src(appSourcesAndCSS, { read: false });
    var libSources = gulp.src(debugInjectSrcs, { read: false });

    return doInject(target, appSources, libSources);
});

var doInject = function (target, appSrc, libSrc) {

    var thirdPartyCSS = gulp.src(['./dist/lib/*.css']);

    return target.pipe(inject(libSrc, { name: 'thirdparty', addRootSlash: false }))
        .pipe(inject(thirdPartyCSS, { name: 'thirdpartycss', addRootSlash: false }))
        .pipe(inject(appSrc, { addRootSlash: false }))
        .pipe(gulp.dest('./'));
};

gulp.task('default', ['debugIndex'], function () { });
