<template>
  <div class="theaters">
    <div class="hero-body">
      <h1>CECS Theatre Dept. |</h1>The Fantastic 5 Ampitheatre
      <div class="container has-text-centered">
        <div class="columns is-vcentered">
          <div class="column is-6 is-half">
            <h1 class="title is-2">Ticket Selling</h1>
            <h2 class="subtitle is-4">
              <h2>Production Name
                <p>
                  <input
                    v-model="info.ProductionName"
                    name="Production Name"
                    placeholder="Enter production name"
                  >
                </p>
              </h2>
              <h2>Director First Name
                <p>
                  <input
                    v-model="info.DirectorFirstName"
                    name="Director Name"
                    placeholder="Enter first name"
                  >
                </p>
              </h2>
              <h2>Director Last Name
                <p>
                  <input
                    v-model="info.DirectorLastName"
                    name="Last Name"
                    placeholder="Enter last name"
                  >
                </p>
              </h2>
              <h2>Street
                <p>
                  <input v-model="info.Street" name="Street" placeholder="Enter street">
                </p>
              </h2>
              <h2>City
                <p>
                  <input v-model="info.City" name="City" placeholder="Enter city">
                </p>
              </h2>
              <h2>State
                <p>
                  <input v-model="info.StateProvince" name="State" placeholder="Enter state">
                </p>
              </h2>
              <h2>Country
                <p>
                  <input v-model="info.Country" name="Country" placeholder="Enter country">
                </p>
              </h2>
              <h2>Zipcode
                <p>
                  <input v-model="info.Zipcode" name="Zipcode" placeholder="Enter zipcode">
                </p>
              </h2>
              <p>
                <input type="Submit" v-on:click="submitProduction" name="Submit">
              </p>
            </h2>
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
            <span class="button is-danger is-large" v-if="!isAdmin">
              <router-link to="/theater/{theaterid}/userproductioninfo">Past Productions</router-link>
            </span>
            <span class="button is-danger is-large" v-if="isAdmin">
              <router-link to="/theater/{theaterid}/adminproductioninfo">Past Productions</router-link>
            </span>
          </div>
          <div class="control">
            <span class="button is-danger is-large">Information / Contact Us</span>
          </div>
          <div class="control">
            <span class="button is-danger is-large" v-if="!isAdmin">
              <router-link to="/theater/{theaterid}/helpwanted/apply">Help Wanted</router-link>
            </span>
            <span class="button is-danger is-large" v-if="isAdmin">
              <router-link to="/theater/{theaterid}/helpwanted">Help Wanted</router-link>
            </span>
            <label class="checkbox">
              <input type="checkbox" v-model="isAdmin">
              Are you an admin?
            </label>
            {{ isAdmin }}
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Theaters",
  data() {
    return {
      info: {
        ProductionName: "",
        DirectorFirstName: "",
        DirectorLastName: "",
        Street: "",
        City: "",
        StateProvince: "",
        Country: "",
        Zipcode: ""
      }
    };
  },
  mounted() {},
  methods: {
    submitProduction() {
      axios
        .post(
          "http://api.broadwaybuilder.xyz/production/createproduction",
          this.info,
          {
            headers: {
              "content-type": "application/json"
            }
          }
        )
        .then(response => console.log(response.data))
        .catch(error => console.log(error));
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
</style>
