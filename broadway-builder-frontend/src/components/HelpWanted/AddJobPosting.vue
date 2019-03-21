<template>
  <div>
    <div class="card">
      <header class="card-header">
        <p class="card-header-title">
          <input class="input" v-model="job.Title" placeholder="Title / Subject">
        </p>
      </header>
      <div class="card-content">
        <div class="columns">
          <div class="column is-6 is-narrow">

            <!-- Show inputs for the adding a new job posting -->
            <div class="content" v-for="(category, index) in categories" v-bind:key="index">
              <strong>{{ category }}</strong>
              <div class="control">

                <!-- Description input -->
                <div v-if="index === 0">
                  <textarea v-model="job.Description" class="textarea"></textarea>
                </div>

                <!-- Hours input -->
                <div v-else-if="index === 1">
                  <textarea v-model="job.Hours" class="textarea"></textarea>
                </div>

                <!-- Requirements input -->
                <div v-else>
                  <textarea v-model="job.Requirements" class="textarea"></textarea>
                </div>
              </div>
            </div>
          </div>
          <div class="column is-6 is-narrow">
            <strong>Type of Job</strong>
            <br>
            <input type="radio" id="jobType" value="Theater" v-model="jobType">
            <label for="one">Theater</label>
            
            <input type="radio" id="jobType" value="Production" v-model="jobType">
            <label for="two">Production</label>
            <br>
            <br>
          </div>
        </div>
      </div>

      <!-- Footer to ADD a job or CANCEL -->
      <footer class="card-footer">
        <a v-on:click="addNewJobPosting" class="card-footer-item">Add</a>
        <a v-on:click="cancelNewJobPosting" class="card-footer-item">Cancel</a>
      </footer>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      categories: ["Description", "Hours", "Requirements"],
      job: {
        Title: "",
        Description: "",
        Hours: "",  
        Requirements: "",
        Position: "Actor",
        theaterid: 1
      },
      jobType: "",
      show: true
    };
  },
  methods: {
    async addNewJobPosting() {
      // Sends a new job posting to the database
      await axios
        .post("http://api.broadwaybuilder.xyz/helpwanted/createtheaterjob", this.job)
        // NOTE: For testing purposes
        // .post("http://localhost:64512/helpwanted/createtheaterjob", this.job)
        .then(response => console.log(response), this.$emit("add", this.job));

    },
    // Cancel the creation of a new job
    cancelNewJobPosting() {
      this.$emit("cancel", false);
    }
  }
};
</script>


<style lang="sass" scoped>
@import '../../../node_modules/bulma/bulma.sass'

.card    
  margin: 1.25em 0 1.25em 0
  box-shadow: 0 14px 28px rgba(0,0,0,0.19), 0 10px 10px rgba(0,0,0,0.22)

a
  color: #6F0000

#jobType
  margin: 1em

</style>


