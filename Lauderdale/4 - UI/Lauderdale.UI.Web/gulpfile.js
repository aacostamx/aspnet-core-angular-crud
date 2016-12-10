var gulp = require('gulp');
var clean = require('gulp-clean');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var jsmin = require('gulp-jsmin');

var path = {
    angular: {
        src: [
            './App/lauderdale.module.js',
            './App/Services/lauderdale.city.service.js',
            './App/Controllers/lauderdale.city.controller.js'
        ],
        dist: './wwwroot/js/'
    }
};

gulp.task('copy_angular', function () {
    return gulp
        .src(path.angular.src)
        .pipe(concat('app.min.js'))
        .pipe(jsmin())
        .pipe(gulp.dest(path.angular.dist));
});

gulp.task('copy', ['copy_angular']);