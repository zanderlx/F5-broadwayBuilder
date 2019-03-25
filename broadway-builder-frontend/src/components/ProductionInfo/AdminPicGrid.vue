<template>
  <div class="AdminPicGrid">
    <div class="columns is-multiline">
      <div class="column is-one-quarter-desktop is-half-tablet">
        <div class="card">
          <div class="card-image">
            <figure class="image isrounded is-3by2">
              <img class="isrounded" src="@/assets/download.png" alt>
            </figure>
            <div class="card-content is-overlay is-clipped">
              <span class="tag is-info">INSERT TITLE OF SHOW HERE</span>
            </div>
          </div>
          <footer class="card-footer">
            <div class="card-footer-item">
              <a>Edit Pictures</a>|
              <a>Add New Program</a>
            </div>
          </footer>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "AdminPicGrid"
};
</script>

<style lang="sass" scoped>
@import '../../../node_modules/bulma/bulma.sass'

.card
  border-radius: 6px
  overflow: hidden
  box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22)
  margin: 1em 0 1em 0

.card-footer-item 
    color: black
a
  color: black
</style>