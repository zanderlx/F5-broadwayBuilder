<template>
<body>
  <div class="sysadminaccount">
    <div class="container">
      <div class="columns">
        <div class="column is-3">
          <aside class="menu">
            <p style="padding-top: 15px" class="menu-label">System Administration</p>
            <ul class="menu-list">
              <li>
                <a v-on:click="publishComponent">Publish Site</a>
                <a>Manage Users</a>
                <ul>
                  <li>
                    <a>Theater Administrators</a>
                  </li>
                  <li>
                    <a>Users</a>
                  </li>
                  <li>
                    <a>Blacklist</a>
                  </li>
                </ul>
              </li>
            </ul>
            <p class="menu-label">Financial</p>
            <ul class="menu-list">
              <li>
                <a>List of Theaters</a>
              </li>
            </ul>
            <p class="menu-label">Help Wanted</p>
            <ul class="menu-list">
              <li>
                <a>Job Postings</a>
              </li>
            </ul>
          </aside>
        </div>
        <div class="column is-9">
          <section class="hero is-info welcome is-small">
            <div class="hero-body">
              <div class="container">
                <h1 class="title">Hello, System Admin.</h1>
                <h2 class="subtitle">Get back to work! :D</h2>
              </div>
            </div>
          </section>
          <div class="column is-9">
            <PublishSite
              v-if="publishComp === true"
              v-bind:website="website"
              @cancel="cancelPublish"
            />
          </div>
        </div>
      </div>
    </div>
  </div>
</body>
</template>

<script>
import PublishSite from "@/components/SystemAdmin/PublishSite.vue";
export default {
  name: "SysAdminAccount",
  components: {
    PublishSite
  },
  data() {
    return {
      website: {
        key: "key",
        apptitle: "Broadway Builder",
        description: "We are cool people.",
        logo: "insertpic",
        undermaintenance: false
      },
      publishComp: false
    };
  },
  methods: {
    publishComponent() {
      this.publishComp = !this.publishComp;
    },
    cancelPublish(cancel) {
      this.publishComp = false;
    }
  }
};
</script>

<style lang="sass">

.card
  &.events-card
    background-color: white
    -webkit-box-shadow: 0 2px 3px rgba(10, 10, 10, 0.1), 0 0 0 1px rgba(10, 10, 10, 0.1)
    box-shadow: 0 2px 3px rgba(10, 10, 10, 0.1), 0 0 0 1px rgba(10, 10, 10, 0.1)
    color: #4a4a4a
</style>
