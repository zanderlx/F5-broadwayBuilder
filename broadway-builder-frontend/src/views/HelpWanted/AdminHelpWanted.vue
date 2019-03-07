<template>
  <div class="AdminHelpWanted">
    
    <h1>Job Opportunities | <span><h3>The Great Douchess</h3></span></h1>

    <div class="columns">
      <div class="column is-2 is-narrow">
        <AdminControls/>
        <JobFilter/>
      </div>
      <div class="column is-5">
        <JobPosting/>
        <JobPosting/>
      </div>
      <div class="column is-5">
        <JobPosting/>
      </div>
    </div>
  </div>
</template>

<script>
import JobPosting from "@/components/HelpWanted/JobPosting.vue";
import AdminControls from "@/components/HelpWanted/AdminControls.vue";
import JobFilter from "@/components/HelpWanted/JobFilter.vue";

export default {
  name: "AdminHelpWanted",
  components: {
    JobPosting,
    AdminControls,
    JobFilter
  }
};
</script>

<style lang="sass" scoped>
@import '../../../node_modules/bulma/bulma.sass'

.columns
  margin: 1em

</style>
