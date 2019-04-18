<template>
  <div class="JobFilter">
    <div class="card">
      <strong>
        <u>Filters</u>
      </strong>

      <!-- Filter For Job Types -->
      <div>
        <h4>
          <strong>Type</strong>
        </h4>
        <span v-for="(job, i) in jobTypes" :key="i">
          <input type="checkbox" :value="job.jobType" v-model="filters" @change="applyFilter">
          {{job.jobType}}
          <br>
        </span>
        <hr>
      </div>

      <!-- Filter For Roles -->
      <div>
        <h4>
          <strong>Roles</strong>
        </h4>
        <span v-for="(role, i) in roles" :key="i">
          <input type="checkbox" :value="role.title" v-model="filters" @change="applyFilter">
          {{ role.title }}
          <br>
        </span>
        <hr>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "JobFilter",
  props: ["jobPostings"],
  data() {
    return {
      jobTypes: [
        { jobType: "Full Time" },
        { jobType: "Part Time" },
        { jobType: "Seasonal" }
      ],
      roles: [
        { title: "Actor" },
        { title: "Stagehands" },
        { title: "Backstage" },
        { title: "Stage Manager" },
        { title: "Wardrobe Supervisor" },
        { title: "Scenic Artist" },
        { title: "Director" },
        { title: "Producer" },
        { title: "Usher" },
        { title: "Dresser" }
      ],
      filters: []
    };
  },
  methods: {
    applyFilter() {
      this.$emit("filtered", this.filters);
    }
  }
};
</script>

<style lang="sass" scoped>
.JobFilter
  margin-top: 1em

.card
  padding: 1em
  box-shadow: 0 14px 75px rgba(0,0,0,0.19), 0 10px 10px rgba(0,0,0,0.22)

</style>
