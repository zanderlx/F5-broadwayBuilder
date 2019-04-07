<template>
  <div>
    <div class="field">
      <div class="control">
        <label class="label">Theater Name</label>
        <input class="input" v-model="theater.TheaterName">
      </div>
    </div>
    <div class="field">
      <div class="control">
        <label class="label">Company Name</label>
        <input class="input" v-model="theater.CompanyName">
      </div>
    </div><div class="field">
      <div class="control">
        <label class="label">Street Address</label>
        <input class="input" v-model="theater.StreetAddress">
      </div>
    </div><div class="field">
      <div class="control">
        <label class="label">City</label>
        <input class="input" v-model="theater.City">
      </div>
    </div><div class="field">
      <div class="control">
        <label class="label">State</label>
        <input class="input" v-model="theater.State">
      </div>
    </div><div class="field">
      <div class="control">
        <label class="label">Country</label>
        <input class="input" v-model="theater.Country">
      </div>
    </div><div class="field">
      <div class="control">
        <label class="label">Phone Number</label>
        <input class="input" v-model="theater.PhoneNumber">
      </div>
    </div>
    <div class="field">
          <div class="control">
            <button v-on:click="createTheater" class="button is-link">Submit</button>
          </div>
          <div class="control">
            <button v-on:click="cancelTheaterCreation" class="button is-text">Cancel</button>
          </div>
        </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "CreateTheater",
  data() {
    return {
      theater: {
        TheaterName: "",
        CompanyName: "",
        StreedAddress: "",
        City: "",
        State: "",
        Country: "",
        PhoneNumber: ""
      }
    };
  },
  methods: {
    async createTheater() {
      await axios
      .post("https://api.broadwaybuilder.xyz/theater/createtheater", this.theater)
      .then(response => {console.log(response)});
    },
    cancelTheaterCreation() {
      this.$emit("cancelCreateTheater", false);
    }
  }
};
</script>
