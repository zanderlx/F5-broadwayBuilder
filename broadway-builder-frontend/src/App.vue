<template>
<div id="app">
<nav class="navbar is-danger" role="navigation" aria-label="main navigation">
  <div class="navbar-brand">
    <a class="navbar-item">
      <img src="@/assets/download.png">
    </a>
    <div class="MainTitle">Broadway Builder</div>

    <a role="button" class="navbar-burger burger" aria-label="menu" aria-expanded="false" data-target="navbarBasicExample">
      <span aria-hidden="true"></span>
      <span aria-hidden="true"></span>
      <span aria-hidden="true"></span>
    </a>
  </div>

  <div id="navbarBasicExample" class="navbar-menu">
    <div class="navbar-start">
      <a class="navbar-item">
        Home
      </a>

      <a class="navbar-item" to="/about">
        About
      </a>
    </div>

    <div class="navbar-end">
      <div class="navbar-item">
        <div class="buttons">
          <a class="button is-light">
            Login / Sign up
          </a>
        </div>
      </div>
    </div>
  </div>
  
</nav>
<router-view/>
</div>
</template>

<style lang="sass">
@import '../node_modules/bulma/bulma.sass'
@import url('https://fonts.googleapis.com/css?family=Roboto');

nav 
  background-image: linear-gradient(to right, #6F0000, #200122)
  font-family: 'Roboto'
  font-weight: bold
  font-size: 1.5em
  color: #DEDEDE
  text-shadow: 1.5px 1.5px black
  
  

.navbar-menu
  font-weight: normal

.MainTitle
  line-height: 55px

.buttons
  text-shadow: 0px 0px white

router-link
  color: white

</style>