<template>
  <v-app>
    <HelloWorld>test</HelloWorld>
  </v-app>
  
</template>

<script lang="ts">
import Vue from 'vue';
import HelloWorld from './components/HelloWorld.vue'

export default Vue.extend({
  name: 'App',

  components: {
    HelloWorld
  },

  mounted: () => ({
  }),

  data: () => ({
    //
  }),
});
</script>
