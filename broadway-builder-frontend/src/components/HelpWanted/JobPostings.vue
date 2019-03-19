<template>
  <div>
    <div class="columns" v-for="(item, index) in jobPostings" v-bind:key="index">
      <div class="column is-6">
        <div class="card">
          <header class="card-header">
            <p class="card-header-title">
              <strong id="Title">{{ item.Title }}</strong>
            </p>
          </header>
          <div class="card-content">
            <div class="content">
              <strong>Description</strong>
              <p id="Description">{{ item.Description }}</p>
            </div>
          </div>
          <footer class="card-footer">
            <a v-on:click="item.show = true" class="card-footer-item">View</a>
          </footer>
        </div>
      </div>
      <div class="column is-6">
        <div class="card" v-if="item.show === true">
          <header class="card-header">
            <p class="card-header-title">
              <strong id="Title">{{ item.Title }}</strong>
            </p>
            <a v-on:click="item.show = false" class="card-header-icon" aria-label="more options">
                <span class="icon">
                  <FontAwesomeIcon icon="times"/>
                </span>
              </a>
          </header>
          <div class="card-content">
            <div class="content">
              <strong>Description</strong>
              <p id="Description">{{ item.Description }}</p>
            </div>
            <div class="content">
              <strong>Hours</strong>
              <p id="Hours">{{ item.Hours }}</p>
            </div>
            <div class="content">
              <strong>Requirements</strong>
              <p id="Requirements">{{ item.Requirements }}</p>
            </div>
          </div>
          <footer class="card-footer">
            <a v-on:click="editJobPosting(index)" class="card-footer-item">Edit</a>
            <a v-on:click="removeJobPosting(item, index)" class="card-footer-item">Delete</a>
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
    removeJobPosting(item, index) {
      item.show = false;
      this.jobPostings.splice(index, 1);
      this.$emit('removed', this.jobPostings)
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


