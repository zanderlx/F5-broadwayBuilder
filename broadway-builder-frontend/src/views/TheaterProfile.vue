<template>
  <div class="theaterprofile">
    <div class="hero-body">
      <h1>{{theater.TheaterName}} |</h1>
      {{theater.CompanyName}}
      <div class="container has-text-centered">
        <div class="columns is-vcentered">
          <div class="column is-6 is-half">
            <h1 class="title is-2">Ticket Selling</h1>
            <h2 class="subtitle is-4">Coming soon to a browser near you!</h2>
          </div>

          <div class="column is-5 is-half">
            <figure class="image is-4by3">
              <img src="@/assets/download.png" class="backpic" alt="Custom Pic">
              <figure class="image is-128x128">
                <img src="@/assets/logo.png" class="profpic is-rounded" alt="Profile Pic">
              </figure>
            </figure>
          </div>
        </div>
      </div>
    </div>

    <div class="hero-foot">
      <div class="columns is-mobile is-centered">
        <div class="field is-grouped is-grouped-multiline">
          <div class="control">
            <span
              v-on:click="goToPictures(theater)"
              class="button is-danger is-rounded is-medium"
            >Past Productions</span>
          </div>
          <div class="control">
            <span class="button is-danger is-rounded is-medium">Information / Contact Us</span>
          </div>
          <div class="control">
            <span class="button is-danger is-rounded is-medium">
              <router-link to="/theater/{theaterid}/helpwanted/apply">Help Wanted</router-link>
            </span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "TheaterProfile",
  data() {
    return {
      TheaterName: this.$route.params.TheaterName,
      theater: {}
    };
  },
  async mounted() {
    await axios
      .get("https://api.broadwaybuilder.xyz/theater/" + this.TheaterName)
      .then(response => (this.theater = response.data));
  },
  methods: {
    goToPictures(theater) {
      this.$router.push({
        name: "userproductioninfo",
        params: {
          TheaterID: theater.TheaterID
        }
      });
    }
  }
};
</script>


<style scoped>
.button {
  background-image: linear-gradient(to right, #6f0000, #200122);
  font-family: "Roboto";
  font-weight: bold;
  font-size: 1.5em;
  color: #dedede;
  text-shadow: 1.5px 1.5px black;
}

h1 {
  font-size: 3em;
}

.backpic {
  position: absolute;
  top: 10px;
  left: 10px;
  z-index: 1;
}
.profpic {
  position: absolute;
  top: 25px;
  left: 25px;
  z-index: 2;
}

.card-footer-item {
  color: black;
}

.button {
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease 0s;
  align: center;
}

.button:hover {
  background-color: #6f0000;
  box-shadow: 0px 15px 20px rgba(0, 0, 0, 0.4);
  color: #fff;
  transform: translateY(-7px);
}
</style>
