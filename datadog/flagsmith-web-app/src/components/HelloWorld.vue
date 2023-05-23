<template>
  <div class="hello">
    <h3>任务</h3>
    <ul>
      <li>当一个 Feature Flags 打开，并 TIP, Progressive Release 后，是否可以通过检测 Error 出现率来进行 issue 通报呢？</li>
      <li><a href="https://vuex.vuejs.org" target="_blank" rel="noopener">vuex</a></li>
      <li><a href="https://github.com/vuejs/vue-devtools#vue-devtools" target="_blank" rel="noopener">vue-devtools</a>
      </li>
      <li><a href="https://vue-loader.vuejs.org" target="_blank" rel="noopener">vue-loader</a></li>
      <li><a href="https://github.com/vuejs/awesome-vue" target="_blank" rel="noopener">awesome-vue</a></li>
    </ul>
    <h3>Guance & FeatBit</h3>
    <ul>
      <li v-if="flagSmithStore.flags['feature-a'] === true"><a @click="sendAction('feature-a')" style="cursor: pointer;"
          rel="noopener">Feature A</a></li>
      <li v-if="flagSmithStore.flags['feature-b'] === true"><a @click="sendAction('feature-b')" style="cursor: pointer;"
          rel="noopener">Feature B</a></li>
    </ul>
    <h4>Simulate Exception</h4>
    <a @click="simulateException">Simulate an exception</a>
  </div>
</template>

<script>

import { useFlagSmithStore } from '@/flagSmithPinia';

export default {
  name: 'HelloWorld',
  setup() {
    const flagSmithStore = useFlagSmithStore();
    
    return {
      flagSmithStore
    }
  },
  methods: {
   /* eslint-disable */
    sendAction(event) {
      console.log(event);
    },
    simulateException(){
      throw "SimpulatedException";
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}

/* ul {
  list-style-type: none;
  padding: 0;
} */

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>
