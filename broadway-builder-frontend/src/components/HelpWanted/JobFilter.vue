<template>
  <div class="JobFilter">
    <div class="card">
      <strong><u>Filters</u></strong>

      <!-- Filter For Job Types -->
      <div>
        <h4><strong>Type</strong></h4>
        <span v-for="(job, i) in jobTypes" :key="i">
          <input type="checkbox" :value="job.jobType" v-model="selectedJobTypes">
            {{job.jobType}} <br>
        </span>
        <hr>
        <span v-if="selectedJobTypes.length > 0">Selected Job Types: {{ selectedJobTypes }}</span>
      </div>

      <!-- Filter For Roles -->
      <div>
        <h4><strong>Roles</strong></h4>
        <span v-for="(role, i) in roles" :key="i">
          <input type="checkbox" :value="role.title" v-model="selectedRoles">
            {{ role.title }} <br>
        </span>
        <hr>
        <span v-if="selectedRoles.length > 0">
          Selected Role Types: {{ selectedRoles }}
        </span>
      </div>

    </div>
  </div>
</template>

<script>
export default {
  name: "JobFilter",
  data() {
    return {
      jobTypes: [
        { jobType: "Full Time" },
        { jobType: "Part Time" },
        { jobType: "Seasonal"}
      ],
      selectedJobTypes: [],
      roles: [
        { title: "Actors" },
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
      selectedRoles: []
    };
  }
};
</script>

<style lang="sass" scoped>
.JobFilter
  margin-top: 1em

.card
  padding: 1em
  box-shadow: 0 14px 28px rgba(0,0,0,0.19), 0 10px 10px rgba(0,0,0,0.22);

</style>
