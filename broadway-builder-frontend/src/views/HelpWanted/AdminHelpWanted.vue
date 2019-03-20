<template>
  <div class="AdminHelpWanted">
    <div class="columns">
      <div class="column is-2 is-narrow">
        <a class="button is-rounded is-medium" v-on:click="addJobButton">Post A New Job</a>
        <JobFilter/>
      </div>
      <div class="column is-10">
        <AddJobPosting
          v-if="addJob === true"
          @add="newJobPostingSuccess"
          @cancel="cancelNewJobPosting"
        />
        <JobPostings v-bind:jobPostings="jobs" @removed="removeJobPosting"/>
      </div>
    </div>
  </div>
</template>

<script>
import AddJobPosting from "@/components/HelpWanted/AddJobPosting.vue";
import JobPostings from "@/components/HelpWanted/JobPostings.vue";
import JobFilter from "@/components/HelpWanted/JobFilter.vue";

// NOTE: axios will be needed when data store is set up
import axios from "axios";

export default {
  name: "AdminHelpWanted",
  components: {
    AddJobPosting,
    JobPostings,
    JobFilter
  },
  data() {
    return {
      jobs: [],
      addJob: false
    };
  },
  methods: {
    addJobButton() {
      this.addJob = true;
    },
    newJobPostingSuccess(newJob) {
      this.jobs.unshift(newJob);
      this.addJob = true;
    },
    cancelNewJobPosting(canceled) {
      this.addJob = canceled;
    },
    removeJobPosting(updatedJobPostings) {
      this.jobs = updatedJobPostings;
    }
  },
  async mounted() {
    // NOTE: When data store is set up, GET the job postings from the data store
    await axios
      .get("http://localhost:64512/helpwanted/13")
      .then(response => this.jobs = response.data, console.log(this.jobs))

    for (var i = 0; i < this.jobs.length; i++) {
      this.$set(this.jobs[i], "show", false)
    }

    console.log(this.jobs[0].show)
  }
};
</script>

<style lang="sass" scoped>
@import '../../../node_modules/bulma/bulma.sass'

.columns
  margin: 1em

.card    
  margin: 1.25em 0 1.25em 0
  box-shadow: 0 14px 128px rgba(0,0,0,0.19), 0 10px 10px rgba(0,0,0,0.22)

.button
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease 0s;
  align: center

.button:hover
  background-color: #6F0000;
  box-shadow: 0px 15px 20px rgba(0, 0, 0, 0.4);
  color: #fff;
  transform: translateY(-7px);

</style>
