<template>
  <div class="hello">
    <h1>{{ info }}</h1>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'HelloWorld',
  data() {
    return {
      info: ''
    }
  },
  mounted() {
    axios
<<<<<<< HEAD
      .get("http://api.broadwaybuilder.xyz/helloworld")
=======
      .get("http://broadwaybuilder.xyz/helloworld")
>>>>>>> e431edf614ad686310ab408a39857bcb0b5b2838
      .then(response => (this.info = response.data))
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
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
