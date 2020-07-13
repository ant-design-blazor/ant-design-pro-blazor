var gulp = require('gulp'),
  cleanCss = require('gulp-clean-css'),
  less = require('gulp-less'),
  rename = require('gulp-rename'),
  npmImport = require("less-plugin-npm-import");

gulp.task('less', function () {
  return gulp
    .src('styles/index.less')
    .pipe(less({
      javascriptEnabled: true,
      plugins: [new npmImport({ prefix: '~' })]
    }))
    .pipe(cleanCss({ compatibility: '*' }))
    .pipe(rename('site.css'))
    .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('default', gulp.parallel('less'), function () { })