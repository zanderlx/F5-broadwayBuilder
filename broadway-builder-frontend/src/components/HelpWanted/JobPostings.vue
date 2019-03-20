<template>
  <div>
    <div class="columns" v-for="(job, index) in jobPostings" v-bind:key="index">
      <div class="column is-6">
        <div class="card">
          <header class="card-header">
            <p class="card-header-title">
              <strong id="Title">{{ job.Title }}</strong>
            </p>
          </header>
          <div class="card-content">
            <div class="content">
              <strong>Description</strong>
              <p id="Description">{{ job.Description }}</p>
            </div>
          </div>
          <footer class="card-footer">
            <a class="card-footer-item" v-on:click="job.show = !job.show">View</a>
          </footer>
        </div>
      </div>
      <div class="column is-6">
        <div class="card" v-if="job.show">
          <header class="card-header">
            <p class="card-header-title">
              <strong id="Title">{{ job.Title }}</strong>
            </p>
            <a v-on:click="job.show = false" class="card-header-icon" aria-label="more options">
                <span class="icon">
                  <FontAwesomeIcon icon="times"/>
                </span>
              </a>
          </header>
          <div class="card-content">
            <div class="content">
              <strong>Description</strong>
              <p id="Description">{{ job.Description }}</p>
            </div>
            <div class="content">
              <strong>Hours</strong>
              <p id="Hours">{{ job.Hours }}</p>
            </div>
            <div class="content">
              <strong>Requirements</strong>
              <p id="Requirements">{{ job.Requirements }}</p>
            </div>
          </div>
          <footer class="card-footer">
            <a v-on:click="editJobPosting(index)" class="card-footer-item">Edit</a>
            <a v-on:click="removeJobPosting(job, index)" class="card-footer-item">Delete</a>
          </footer>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { library } from "@fortawesome/fontawesome-svg-core";
import { faTimes } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
// import axios from 'axios';
library.add(faTimes);
export default {
  components: {
    FontAwesomeIcon
  },
  props: ["jobPostings"],
  data() {
    return {
      categories: ["Description", "Hours", "Requirements"]
    };
  },
  methods: {
    // async removeJobPosting(job, index) {
    //   await axios
    //     .delete('http://localhost:64512/helpwanted/deletetheaterjob/12')
    //     .then(
    //       this.jobPostings.splice(index, 1),
    //       job.show = false,
    //       this.$emit('removed', this.jobPostings)
    //     )
    //},
    showDetails(job) {
      job.show = true
      console.log(job.show)
    }
  }
};
</script>

<style lang="sass" scoped>
@import '../../../node_modules/bulma/bulma.sass'

.card    
  margin: 1.25em 0 1.25em 0
  box-shadow: 0 14px 75px rgba(0,0,0,0.19), 0 10px 10px rgba(0,0,0,0.22)

.card-header-icon
  color: #6F0000

.card-footer-item
  transition: all 0.3s ease 0s;

.card-footer-item:hover
  transform: translateY(-7px);

a 
  color: #6F0000


</style>


