/// <binding BeforeBuild='concurrent' />
module.exports = grunt => {
    require('load-grunt-tasks')(grunt);
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        concurrent: {
            options: {
                logConcurrentOutput: true
            },
            style: ['sass', 'cssmin', 'concat_css'],
            js: ['concat', 'uglify']

        },
        sass: {
            options: {
                sourceMap: true,
                mangle: true
            },
            dist: {
                src: ['Content/base.scss'],
                dest: 'Content/Temp/styles.css'
            }
        },
        cssmin: {
            target: {
                files: [{
                    expand: true,
                    cwd: 'Content/Temp',
                    src: ['styles.css'],
                    dest: 'Content/Temp/Minified',
                    ext: '.min.css'
                }]
            }
        },
        concat_css: {
            dist: {
                src: ['Content/Temp/Minified/*.css', 'Content/*.min.css'],
                dest: 'Styles/styles.css'
            }
        },
        concat: {
            options: {
                separator: "\r\n\r\n/*-+++ BREAK LINE +++-*/\r\n\r\n"
            },
            dist: {
                src: [
                    'Scripts/jquery-3.2.1.min.js',
                    'Scripts/jquery-ui-1.12.1.min.js',
                    'Scripts/bootstrap.min.js', 
                    'Scripts/jquery.validate-vsdoc.js',
                    'Scripts/jquery.validate.min.js',
                    'Scripts/jquery.validate.unobtrusive.min.js',
                    'Scripts/respond.matchmedia.addListener.min.js',
                    'Scripts/jquery.Jcrop.min.js',
                    'Scripts/respond.min.js', 
                    'Scripts/jquery.unobtrusive-ajax.min.js',
                    'Scripts/knockout-3.4.2.js',
                    'Scripts/jquery.barrating.js',
                    'Scripts/Custom/functions.js'
                ],
                dest: 'Scripts/Temp/scripts.js'
            }
        },
        uglify: {
            dev:
            {
                options: {
                    mangle: true
                },
                files: {
                    'Scripts/Final/js.js': 'Scripts/Temp/scripts.js'
                }
            }
        },
        watch: {
            css: {
                files: 'Content/base.scss',
                tasks: ['sass', 'cssmin', 'concat_css'],
                options: {
                    livereload: true
                }
            },
            options: {
                dateFormat: function (time) {
                    grunt.log.writeln('Watch finished in ' + time + 'ms on ' + (new Date()).toString());
                    grunt.log.writeln('Waiting for more changes...');
                }
            },
            scripts: {
                files: 'Scripts/Custom/functions.js',
                tasks: 'concurrent:js',
                options: {
                    livereload: true
                }
            },
            configFiles: {
                files: ['Gruntfile.js'],
                options: {
                    reload: true
                }
            }
        }
    });
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.registerTask('default', [
        'concurrent:js',
        'concurrent:style'
    ]);
};