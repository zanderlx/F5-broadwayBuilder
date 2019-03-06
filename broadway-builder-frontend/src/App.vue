<template>
  <div id="app">
    <nav class="navbar is-danger" role="navigation" aria-label="main navigation">
      <div class="navbar-brand">
        <a class="navbar-item">
          <router-link to="/">
            <img src="@/assets/download.png">
          </router-link>
        </a>
        
        <a
          role="button"
          class="navbar-burger burger"
          aria-label="menu"
          aria-expanded="false"
          data-target="navbarBasicExample"
        >
          <span aria-hidden="true"></span>
          <span aria-hidden="true"></span>
          <span aria-hidden="true"></span>
        </a>
      </div>

      <div id="navbarBasicExample" class="navbar-menu">
        <div class="navbar-start">
          <a class="navbar-item">
            <router-link to="/">Broadway Builder</router-link>
          </a>
        </div>

        <div class="navbar-end">
          <a class="navbar-item">
            <router-link to="/">Home</router-link>
          </a>
          
          <a class="navbar-item">
            <router-link to="/theaters">Theatres</router-link>
          </a>
          
          <a class="navbar-item">
            <router-link to="/account">Account</router-link>
          </a>
          
          <a class="navbar-item">
            <router-link to="/contactus">Contact Us</router-link>
          </a>
          <div class="navbar-item">
            <div class="buttons">
              <a class="button is-light">Login / Register</a>
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
  align: right

a
  color: #FFF

a:hover 
   color: white

.buttons
  text-shadow: 0px 0px white
</style>