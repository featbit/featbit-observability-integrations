<template>
  <div class="hello">
    <!-- <h1>{{ msg }}</h1>
    <p>
      For a guide and recipes on how to configure / customize this project,<br>
      check out the
      <a href="https://cli.vuejs.org" target="_blank" rel="noopener">vue-cli documentation</a>.
    </p>
    <h3>Installed CLI Plugins</h3>
    <ul>
      <li><a href="https://github.com/vuejs/vue-cli/tree/dev/packages/%40vue/cli-plugin-babel" target="_blank"
          rel="noopener">babel</a></li>
      <li><a href="https://github.com/vuejs/vue-cli/tree/dev/packages/%40vue/cli-plugin-eslint" target="_blank"
          rel="noopener">eslint</a></li>
    </ul>
    <h3>Essential Links</h3>
    <ul>
      <li><a href="https://vuejs.org" target="_blank" rel="noopener">Core Docs</a></li>
      <li><a href="https://forum.vuejs.org" target="_blank" rel="noopener">Forum</a></li>
      <li><a href="https://chat.vuejs.org" target="_blank" rel="noopener">Community Chat</a></li>
      <li><a href="https://twitter.com/vuejs" target="_blank" rel="noopener">Twitter</a></li>
      <li><a href="https://news.vuejs.org" target="_blank" rel="noopener">News</a></li>
    </ul> -->
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
      <li v-if="featBitStore.flags['feature-a']== true"><a @click="sendAction" style="cursor: pointer;" rel="noopener">Feature A</a></li>
      <li v-if="featBitStore.flags['feature-b']== true"><a @click="sendAction" style="cursor: pointer;" rel="noopener">Feature B</a></li>
    </ul>
  </div>
</template>

<script>
import { useFeatBitStore } from '@/featbit';

export default {
  name: 'HelloWorld',
  setup() {
    const featBitStore = useFeatBitStore();

    return {
      featBitStore
    }
  },
  methods: {
    // eslint-disable-next-line
    sendAction(event) {
      if (window.DATAFLUX_RUM)
        console.log(window.DATAFLUX_RUM)
      const user = window.DATAFLUX_RUM.getUser();
      console.log(user)
      window.DATAFLUX_RUM && window.DATAFLUX_RUM.addAction('featbit feature flag service', {
        ffType: "boolean",
        ffKey: "ff-test",
        ffEnv: "development",
        ffProject: "test-web-app",
        ffVariant: true,
        ffUser: {
          id: "1234567890",
          name: "1234567890",
          customized: [
            {
              key: "test",
              value: "test value"
            }
          ]
        }
      });
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
