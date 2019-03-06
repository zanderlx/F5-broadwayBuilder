<template>
  <div class="theaters">
          <div class="hero-body">
            <h1>CECS Theatre Dept. | </h1> The Fantastic 5 Ampitheatre
            <div class="container has-text-centered">
                <div class="columns is-vcentered">
                    <div class="column is-6 is-half">
                        <h1 class="title is-2">
                            Ticket Selling
                        </h1>
                        <h2 class="subtitle is-4">
                            Coming to a browser near you, next sprint! <p>*Insert Component Here</p>
                        </h2>
                    </div>

                    
                    <div class="column is-5 is-half">
                     
                        <figure class="image is-4by3"> 
                          <img src="@/assets/download.png" class ="backpic" alt="Custom Pic">
                          <figure class="image is-128x128">
                            <img src="@/assets/logo.png" class="profpic is-rounded" alt="Profile Pic"></figure>
                             

                        </figure>
                    </div>

                </div>
            </div>
        </div>

        <div class="hero-foot">
          <div class="columns is-mobile is-centered">
            <div class="field is-grouped is-grouped-multiline">
              <div class="control"><span class="button is-danger is-large">Past Productions</span></div>
              <div class="control"><span class="button is-danger is-large">Information / Contact Us</span></div>
              <div class="control">
                <span class="button is-danger is-large">
                  <router-link to="/theater/{theaterid}/helpwanted">Admin Help Wanted</router-link>
                </span>
              </div>
            </div>
          </div>
        </div>
  </div>
</template>

<style scoped>
.button {
  background-image: linear-gradient(to right, #6F0000, #200122);
  font-family: 'Roboto';
  font-weight: bold;
  font-size: 1.5em;
  color: #DEDEDE;
  text-shadow: 1.5px 1.5px black;
}

h1 {
  font-size: 3em;
}

	.backpic
	{
		position:absolute;
		top: 10px;
		left: 10px;
		z-index: 1;
	}
	.profpic
	{
		position:absolute;
		top: 25px;
		left: 25px;
		z-index: 2;
	}
</style>
