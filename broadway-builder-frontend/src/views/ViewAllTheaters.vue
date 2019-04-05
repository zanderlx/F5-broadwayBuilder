<template>
  <div class="ViewAllTheaters">
    <div>
      <div v-for="(theater, index) in theaters" :key="index">
        <div class="card">
          <div class="card-image">
            <figure class="image is-4by3">
              <img src="@/assets/download.png" alt="Placeholder image">
            </figure>
          </div>
          <div class="card-content">
            <div class="media">
              <div class="media-left">
                <figure class="image is-48x48">
                  <img src="@/assets/logo.png" alt="Placeholder image">
                </figure>
              </div>
              <div class="media-content">
                <p class="title is-4">{{theaters.TheaterName}}</p>
                <p class="subtitle is-6">{{}}</p>
              </div>
            </div>
            <div class="content">
              {{theaters.StreetAddress}}
              <br>
              {{theaters.State}}
              <br>
              {{theaters.Country}}
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
//import TheaterProfile from "@/views/TheaterProfile.vue";
import axios from "axios";

export default {
  name: "ViewAllTheaters",
  // components: {
  //   TheaterProfile
  // },
  data() {
    return {
      theaters: [],
      Goto: false
    };
  },
  async mounted() {
    await axios
      .get("http://localhost:64512/theater/all")
      .then(response => (this.theaters = response.data));
  }
};
</script>

<style lang="sass" scoped>
@import '../../node_modules/bulma/bulma.sass'

</style>
