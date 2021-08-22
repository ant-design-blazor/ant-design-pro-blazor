var gulp = require('gulp'),
  cleanCss = require('gulp-clean-css'),
  less = require('gulp-less'),
  rename = require('gulp-rename'),
  concatCss = require("gulp-concat-css"),
  npmImport = require("less-plugin-npm-import");

const sourceFiles = [
  '**/*.less',
  '!node_modules/**',
  '!**/bin/**',
  '!**/obj/**'
];

gulp.task('isolation', function () {
  return gulp
    .src(sourceFiles)
    .pipe(less({
      javascriptEnabled: true,
      plugins: [new npmImport({ prefix: '~' })]
    }))
    .pipe(rename(function (file) {
      if (file.basename == 'global') {
        file.dirname = 'css';
        file.basename = 'site';
      }
    }))
    .pipe(gulp.dest(function (file) {
      if (file.basename == 'site.css') {
        return './wwwroot';
      }
      return '.';
    }));
});

gulp.task('less', function () {
  return gulp
    .src(sourceFiles)
    .pipe(less({
      javascriptEnabled: true,
      plugins: [new npmImport({ prefix: '~' })]
    }))
    .pipe(concatCss('site.css'))
    .pipe(cleanCss({ compatibility: '*' }))
    .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('default', gulp.parallel('isolation'), function () {
});