self.addEventListener('install', function(e) {
    e.waitUntil(
      caches.open('studybuddy-cache').then(function(cache) {
        return cache.addAll([
          '/',
          '/staticfiles/icons/icon-192x192.png',
          '/staticfiles/icons/icon-512x512.png',
        ]);
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
  