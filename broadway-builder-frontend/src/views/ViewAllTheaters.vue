<template>
  <div>
    <div v-for="(theater, index) in theaters" :key="index">
      <div class="card">
        <header class="card-header">
          <p class="card-header-title">Component</p>
          <a href="#" class="card-header-icon" aria-label="more options">
            <span class="icon">
              <i class="fas fa-angle-down" aria-hidden="true"></i>
            </span>
          </a>
        </header>
        <div class="card-content">
          <div class="content">
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus nec iaculis mauris.
            <a
              href="#"
            >@bulmaio</a>.
            <a href="#">#css</a>
            <a href="#">#responsive</a>
            <br>
            <time datetime="2016-1-1">11:09 PM - 1 Jan 2016</time>
          </div>
        </div>
        <footer class="card-footer">
          <router-link class="card-footer-item" to="/theater">
            Save
            <TheaterProfile :theater="theater"/>
          </router-link>

          <a href="#" class="card-footer-item">Edit</a>
          <a href="#" class="card-footer-item">Delete</a>
        </footer>
      </div>
    </div>
  </div>
</template>

<script>
import TheaterProfile from "@/views/TheaterProfile.vue";
import axios from "axios";

export default {
  components: {
    TheaterProfile
  },
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
