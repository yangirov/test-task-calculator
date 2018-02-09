var gulp           = require('gulp'),
		gutil          = require('gulp-util' ),
		sass           = require('gulp-sass'),
		browserSync    = require('browser-sync'),
		concat         = require('gulp-concat'),
		uglify         = require('gulp-uglify'),
		cleanCSS       = require('gulp-clean-css'),
		rename         = require('gulp-rename'),
		del            = require('del'),
		cache          = require('gulp-cache'),
		autoprefixer   = require('gulp-autoprefixer'),
		notify         = require("gulp-notify");

var distFolder = "../TestMVC/Content/";

gulp.task('js', function() {
	return gulp.src([
		'app/libs/jquery/dist/jquery.min.js',
		'app/libs/modernizr/modernizr-custom.js',
		//'app/libs/bootstrap/bootstrap.min.js'
		])
	.pipe(concat('scripts.min.js'))
	//.pipe(uglify())
	.pipe(gulp.dest('app/js'))
	.pipe(browserSync.reload({stream: true}));
});

gulp.task('browser-sync', function() {
	browserSync({
		server: {
			baseDir: 'app'
		},
		notify: false
	});
});

gulp.task('sass', function() {
	return gulp.src('app/sass/**/*.sass')
	.pipe(sass({outputStyle: 'expand'}).on("error", notify.onError()))
	.pipe(rename({suffix: '.min', prefix : ''}))
	.pipe(autoprefixer(['last 15 versions']))
	.pipe(cleanCSS())
	.pipe(gulp.dest('app/css'))
	.pipe(browserSync.reload({stream: true}));
});

gulp.task('watch', ['sass', 'js', 'browser-sync'], function() {
	gulp.watch('app/sass/**/*.sass', ['sass']);
	gulp.watch(['libs/**/*.js'], ['js']);
	gulp.watch('app/*.html', browserSync.reload);
});

gulp.task('build', ['removedist', 'sass', 'js'], function() {
	/*var buildFiles = gulp.src([
		'app/*.html'
		]).pipe(gulp.dest(distFolder));*/

	var buildJs = gulp.src([
		'app/js/scripts.min.js',
		'app/js/common.js',
		]).pipe(gulp.dest(distFolder + 'js'));

	var buildCss = gulp.src([
		'app/css/main.min.css',
		]).pipe(gulp.dest(distFolder + 'css'));

	var buildFonts = gulp.src([
		'app/fonts/**/*',
		]).pipe(gulp.dest(distFolder + 'fonts'));
});

gulp.task('removedist', function() { return del.sync(distFolder, {force: true}); });
gulp.task('clearcache', function () { return cache.clearAll(); });

gulp.task('default', ['watch']);