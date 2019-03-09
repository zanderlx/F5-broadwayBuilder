<template>
    <div class="UserProductionInfo">
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


</style>