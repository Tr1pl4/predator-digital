// Karma configuration file, see link for more information
// https://karma-runner.github.io/1.0/config/configuration-file.html

module.exports = function (config) {
  const isCI = !!process.env.CI;

  config.set({
    // ...
    autoWatch: !isCI,
    singleRun: isCI,
    restartOnFileChange: !isCI,
    browsers: isCI ? ['ChromeHeadlessNoSandbox'] : ['Chrome'],
    customLaunchers: {
      ChromeHeadlessNoSandbox: {
        base: 'ChromeHeadless',
        flags: ['--no-sandbox', '--disable-gpu', '--disable-dev-shm-usage']
      }
    }
  });
};
