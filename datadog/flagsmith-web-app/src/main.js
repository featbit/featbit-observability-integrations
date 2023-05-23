import { createApp } from 'vue'
import App from './App.vue'
import { createPinia } from 'pinia'
import { datadogRum } from '@datadog/browser-rum';
import { flagSmithPinia } from '@/flagSmithPinia';

// createApp(App).mount('#app')


datadogRum.init({
    applicationId: 'db5c5d13-f6b9-4f9f-bd70-66878787150c',
    clientToken: 'pub7eda8d0b12e1232317b7495956964454',
    site: 'datadoghq.eu',
    service: 'flagsmith-test',
    env: 'testing',
    // Specify a version number to identify the deployed version of your application in Datadog 
    // version: '1.0.0',
    sessionSampleRate: 100,
    sessionReplaySampleRate: 20,
    trackUserInteractions: true,
    trackResources: true,
    trackLongTasks: true,
    defaultPrivacyLevel: 'mask-user-input',
    enableExperimentalFeatures: ["feature_flags"]
});

datadogRum.startSessionReplayRecording();

console.log('datadogRum started');


const pinia = createPinia()
const app = createApp(App)
app.use(pinia)
app.use(flagSmithPinia)
app.mount('#app');

