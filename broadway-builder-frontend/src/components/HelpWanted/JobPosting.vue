<template>
  <div>
    <div v-for="(item, index) in jobPostings" :key="index">

    
  </div>
  </div>
</template>

<script>
export default {
  props: ["jobPostings", "show"],
  data() {
    return {
      categories: ["Description", "Hours", "Requirements"]
    };
  }
};
</script>


<style lang="sass" scoped>
@import '../../../node_modules/bulma/bulma.sass'

.card    
  margin: 1.25em 0 1.25em 0
  box-shadow: 0 14px 28px rgba(0,0,0,0.19), 0 10px 10px rgba(0,0,0,0.22)


</style>


