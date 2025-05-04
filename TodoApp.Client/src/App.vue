<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <header>
    <h1>Dynamic Todo App</h1>
  </header>
  <main>
    <RouterView />
  </main>
  <footer>
    <p>{{ new Date().getFullYear() }} Todo App</p>
  </footer>
</template>

<style scoped>
</style>
