self.addEventListener('install', function(e) {
  e.waitUntil(
    caches.open('studybuddy-cache').then(function(cache) {
      return cache.addAll([
        '/',
        '/static/icon-192x192.png',
        '/static/icon-512x512.png',
        '/static/manifest.json',
        '/static/favicon.ico'
      ]);
    }).catch(function(err) {
      console.error('Ошибка кэширования:', err);
    })
  );
});

self.addEventListener('fetch', function(e) {
  e.respondWith(
    caches.match(e.request).then(function(response) {
      return response || fetch(e.request);
    })
  );
});
