/// <binding BeforeBuild='clean' AfterBuild='lib, min, favicon' ProjectOpened='watch' />
"use strict";

var gulp = require("gulp"),
  concat = require("gulp-concat"),
  cssmin = require("gulp-cssmin"),
  htmlmin = require("gulp-htmlmin"),
  uglify = require("gulp-uglify"),
  merge = require("merge-stream"),
  del = require("del"),
  path = require("path"),
  bundleconfig = require("./bundleconfig.json"),
  nodeassets = require("./node_assets.json");


var gutil = require('gulp-util');



var regex = {
  css: /\.css$/,
  html: /\.(html|htm)$/,
  js: /\.js$/
};

gulp.task("lib:js", function () {
  return gulp.src(nodeassets.js)
    .pipe(gulp.dest("./wwwroot/dist"));
});
gulp.task("lib:css", function () {
  return gulp.src(nodeassets.css)
    .pipe(gulp.dest("./wwwroot/dist"));
});
gulp.task("lib:fonts", function () {
  return gulp.src(nodeassets.fonts)
    .pipe(gulp.dest("./wwwroot/fonts"));
});

gulp.task("lib", ["lib:js", "lib:css", "lib:fonts"]);

gulp.task("favicon", function () {
  return gulp.src("Assets/favicon.ico")
    .pipe(gulp.dest("./wwwroot"));
})

gulp.task("min", ["min:js", "min:css", "min:html"]);

gulp.task("min:js", function () {
  var tasks = getBundles(regex.js).map(function (bundle) {
    return gulp.src(bundle.inputFiles, { base: "." })
      .pipe(concat(bundle.outputFileName))
      .pipe(uglify())
      .on('error', function (err) { gutil.log(gutil.colors.red('[Error]'), err.toString()); })
      .pipe(gulp.dest("."));
  });
  return merge(tasks);
});

gulp.task("min:css", function () {
  var tasks = getBundles(regex.css).map(function (bundle) {
    return gulp.src(bundle.inputFiles, { base: "." })
      .pipe(concat(bundle.outputFileName))
      .pipe(cssmin())
      .pipe(gulp.dest("."));
  });
  return merge(tasks);
});

gulp.task("min:html", function () {
  var tasks = getBundles(regex.html).map(function (bundle) {
    return gulp.src(bundle.inputFiles, { base: "." })
      .pipe(concat(bundle.outputFileName))
      .pipe(htmlmin({ collapseWhitespace: true, minifyCSS: true, minifyJS: true }))
      .pipe(gulp.dest("."));
  });
  return merge(tasks);
});

gulp.task("clean", function () {


  return del(["./wwwroot/dist", "./wwwroot/fonts"]);
});

gulp.task("watch", function () {
  getBundles(regex.js).forEach(function (bundle) {
    gulp.watch(bundle.inputFiles, ["min:js"]);
  });

  getBundles(regex.css).forEach(function (bundle) {
    gulp.watch(bundle.inputFiles, ["min:css"]);
  });

  getBundles(regex.html).forEach(function (bundle) {
    gulp.watch(bundle.inputFiles, ["min:html"]);
  });
});

function getBundles(regexPattern) {
  return bundleconfig.filter(function (bundle) {
    return regexPattern.test(bundle.outputFileName);
  });
}