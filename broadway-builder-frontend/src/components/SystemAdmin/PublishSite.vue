<template>
  <div class="PublishSite">
    <div>
      <div class="column">
        <label class="label">Publish Site</label>

        <div class="field">
          <label class="label">Application Title</label>
          <div class="control">
            <input class="input" v-model="website.apptitle" placeholder="Broadway Builder">
          </div>
        </div>

        <div class="field">
          <label class="label">Description</label>
          <div class="control">
            <textarea v-model="website.description" class="textarea"></textarea>
          </div>
        </div>

        <div class="field">
          <label class="label">Description</label>
          <div class="large-12 medium-12 small-12 cell">
            <input type="file" id="file" ref="website.logo" v-on:change="handleFileUpload()">
          </div>
        </div>

        <div class="field">
          <label class="label">Under Maintenance</label>
          <div class="control">
            <label class="radio">
              <input type="radio" value="true" v-model="website.undermaintenance">
              Yes
            </label>
            <label class="radio">
              <input type="radio" value="false" v-model="website.undermaintenance">
              No
            </label>
          </div>
        </div>

        <div class="field is-grouped">
          <div class="control">
            <button v-on:click="publishApp" class="button is-link">Submit</button>
          </div>
          <div class="control">
            <button v-on:click="cancelPublish" class="button is-text">Cancel</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "PublishSite",
  props: ["website"],
  methods: {
    handleFileUpload() {
      this.website.logo = this.$refs.file;
    },
    cancelPublish() {
      this.$emit("cancel", false);
    },
    async publishApp() {
      await axios.post("api/applications/publish", this.website);
    }
  }
};
</script>

<style lang="sass" scoped>
@import '../../../node_modules/bulma/bulma.sass'


</style>