<template>
  <div class="AdminProductionInfo">
    <h1>CECS Theatre Dept. |</h1>The Fantastic 5 Ampitheatre
    <AdminPicGrid/>
    <AdminPictureWheel/>
  </div>
</template>

<script>
import AdminPicGrid from "@/components/ProductionInfo/AdminPicGrid.vue";
import axios from "axios";

export default {
  name: "AdminProductionInfo"
};
</script>

<style lang="sass" scoped>
@import '../../../node_modules/bulma/bulma.sass'

h1 
  font-size: 3em


</style>