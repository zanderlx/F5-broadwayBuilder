<template>
  <div class="ResumeUpload">
    <form action="">
        <input type="file" id="file" ref="file" v-on:change="handleFileUpload()">
        <p>Drag your files <br> or click in this area</p>
    </form>
  </div>
</template>

<script>
export default {
  name: "ResumeUpload"
};
</script>

<style scoped>
body {
  background: rgba(0, 0, 0, 0.9);
}
form {
  height: 10em;
  border: 4px dashed #fff;
}
form p {
  width: 100%;
  height: 100%;
  text-align: center;
  padding-top: 3em;
  color: #ffffff;
  font-family: Arial;
}
form input {
  position: absolute;
  margin: 0;
  padding: 0;
  width: 100%;
  height: 100%;
  outline: none;
  opacity: 0;
}
</style>
