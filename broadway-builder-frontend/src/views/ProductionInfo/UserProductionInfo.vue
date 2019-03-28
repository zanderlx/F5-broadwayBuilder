<template>
  <div class="UserProductionInfo">
    <h1>CECS Theatre Dept. |</h1>The Fantastic 5 Ampitheatre
    <PicGrid/>
  </div>
</template>

<script>
import PicGrid from "@/components/ProductionInfo/PicGrid.vue";

export default {
  name: "UserProductionInfo",
  components: {
    PicGrid
  }
};
</script>

<style lang="sass" scoped>
@import '../../../node_modules/bulma/bulma.sass'

h1 
  font-size: 3em


</style>