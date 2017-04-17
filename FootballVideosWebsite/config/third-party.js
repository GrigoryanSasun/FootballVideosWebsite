module.exports = {
    vendor: [
        '@angular/animations',
        '@angular/platform-browser',
        '@angular/platform-browser-dynamic',
        '@angular/core',
        '@angular/common',
        '@angular/forms',
        '@angular/http',
        '@angular/router',
        'angular2-infinite-scroll'
    ],
    polyfills: [
        'core-js',
        {
            name: 'zone.js',
            path: 'zone.js/dist/zone.js'
        },
        {
            name: 'zone.js',
            path: 'zone.js/dist/long-stack-trace-zone.js'
        }
    ]
};