<template>
  <div class="ViewAllTheaters">
    <div v-for="(theater, index) in theaters" :key="index">
      <router-link to="/theater">
        <div class="card">
          <div class="card-image">
            <figure class="image is-4by3">
              <img src="https://bulma.io/images/placeholders/1280x960.png" alt="Placeholder image">
            </figure>
          </div>
          <div class="card-content">
            <div class="media">
              <div class="media-left">
                <figure class="image is-48x48">
                  <img src="https://bulma.io/images/placeholders/96x96.png" alt="Placeholder image">
                </figure>
              </div>
              <div class="media-content">
                <p class="title is-4">{{theater.CompanyName}}</p>
                <p class="subtitle is-6">{{theater.TheaterName}}</p>
              </div>
            </div>

            <div class="content">
              A Member Since: {{theater.DateCreated}}
              <br>
              {{theater.StreetAddress}}
              <br>
              {{theater.City}}, {{theater.State}} {{theater.Country}}
            </div>
          </div>
        </div>
      </router-link>
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
      .get("https://api.broadwaybuilder.xyz/theater/all")
      .then(response => (this.theaters = response.data));
  }
};
</script>

<style lang="sass" scoped>
@import '../../node_modules/bulma/bulma.sass'



</style>
