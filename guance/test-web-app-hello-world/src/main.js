import { createApp } from 'vue'
import App from './App.vue'
import { createPinia } from 'pinia'
import { featBit } from '@/featbit'

// createApp(App).mount('#app')


const pinia = createPinia()

const app = createApp(App)
app.use(pinia)
app.use(featBit)
app.mount('#app');