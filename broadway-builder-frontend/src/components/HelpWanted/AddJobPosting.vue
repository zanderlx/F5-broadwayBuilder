<template>
  <div>
    <div class="card">
      <header class="card-header">
        <p class="card-header-title">
          <input class="input" v-model="Title" placeholder="Title / Subject">
        </p>
      </header>
      <div class="card-content">
        <div class="content" v-for="(category, index) in categories" v-bind:key="index">
          <strong>{{ category }}</strong>
          <div class="control">
            <div v-if="index === 0">
              <textarea v-model="Description" class="textarea"></textarea>
            </div>
            <div v-else-if="index === 1">
              <textarea v-model="Hours" class="textarea"></textarea>
            </div>
            <div v-else>
              <textarea v-model="Requirements" class="textarea"></textarea>
            </div>
          </div>
        </div>
      </div>
      <footer class="card-footer">
        <a v-on:click="addNewJobPosting" class="card-footer-item">Add</a>
        <a v-on:click="cancelNewJobPosting" class="card-footer-item">Cancel</a>
      </footer>
    </div>
  </div>
</template>

<script>
import axios from "axios"
export default {
  data() {
    return {
      categories: ["Description", "Hours", "Requirements"],
      "Title": '',
      "Description": '',
      "Hours": '',
      "Requirements": '',
      show: true
    };
  },
  methods: {
    addNewJobPosting() {
      axios
      .post("http://localhost:64512/helpwanted/createtheaterjob", {
        Title: this.Title,
        Description: this.Description,
        Hours: this.Hours,
        Requirements: this.Requirements,
        Position:"frontend",
        theaterid:2
      })
      .then(this.$emit('add', {
        Title: this.Title,
        Description: this.Description,
        Hours: this.Hours,
        Requirements: this.Requirements,
        show: true
      }));
      
    },
    cancelNewJobPosting() {
      this.$emit('cancel', false)
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

</style>


