<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <header>
    <h1 class="text-3xl">Dynamic Todo App</h1>
  </header>
  <main class="flex-1 flex flex-col">
    <RouterView />
  </main>
</template>

<style scoped></style>
