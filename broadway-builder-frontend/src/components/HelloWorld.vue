<template>
  <div class="hello">
    <h1>{{ info }}</h1>

  </div>
</template>

<script>
import axios from 'axios';
export default {
  name: 'HelloWorld',
  props: {
    msg: String
  },
  data() {
    return {
      info: ''
    }
  },
  mounted() {
    axios
      .get('http://api.broadwaybuilder.xyz/helloworld')
      .then(response => (this.info=response.data))
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
