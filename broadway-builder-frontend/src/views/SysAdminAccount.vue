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
                <a v-on:click="performPublish">Publish Site</a>
                <a v-on:click="createTheater"> Create Theater </a>
                <a v-on:click="deleteTheater"> Delete Theater </a>
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
            <PublishSite v-if="publish === true" @cancel="cancelPublish"/>
            <CreateTheater v-if="theaterCreated === true" @cancelCreateTheater="cancelCreateTheater"/>
            <DeleteTheater v-if="theaterDeleted === true" @cancelDeleteTheater="cancelDeleteTheater"/>
          </div>
        </div>
      </div>
    </div>
  </div>
</body>
</template>

<script>
import PublishSite from "@/components/SystemAdmin/PublishSite.vue";
import CreateTheater from "@/components/SystemAdmin/CreateTheater.vue";
import DeleteTheater from "@/components/SystemAdmin/DeleteTheater.vue";

export default {
  name: "SysAdminAccount",
  components: {
    PublishSite,
    CreateTheater,
    DeleteTheater
  },
  data() {
    return {
      publish: false,
      theaterCreated: false,
      theaterDeleted: false,
    };
  },
  methods: {
    performPublish() {
      this.publish = !this.publish;
      this.theaterCreated = false;
      this.theaterDeleted = false;
    },
    cancelPublish(cancel) {
      this.publish = cancel;
    },
    createTheater() {
      this.publish = false;
      this.theaterCreated = !this.theaterCreated;
      this.theaterDeleted = false;
    },
    cancelCreateTheater(cancel) {
      this.theaterCreated = cancel;
    },
    deleteTheater() {
      this.theaterDeleted = !this.theaterDeleted;
      this.publish = false;
      this.theaterCreated = false;
    },
    cancelDeleteTheater(cancel){
      this.theaterDeleted = cancel;
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
