<template>
  <div class="AdminProductionInfo">
    <h1>CECS Theatre Dept. |</h1>The Fantastic 5 Ampitheatre
    <component :is="dynamicComponent"></component>
    <AdminPictureWheel/>
  </div>
</template>

<script>
import AdminPicGrid from "@/components/ProductionInfo/AdminPicGrid.vue";
import AdminPictureWheel from "@/components/ProductionInfo/AdminPictureWheel.vue";

export default {
  name: "AdminProductionInfo",
  components: {
    AdminPicGrid,
    AdminPictureWheel
  },
  props: {
    value: Boolean
  },
  computed: {
    dynamicComponent() {
      if (value) {
        return "AdminPicGrid";
      } else {
        return "AdminPictureWheel";
      }
    }
  }
};
</script>

<style lang="sass" scoped>
@import '../../../node_modules/bulma/bulma.sass'

h1 
  font-size: 3em


</style>