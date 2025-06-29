admins = {
    

    

    "focus@auth.meet.jitsi",
    "jvb@auth.meet.jitsi"
}

unlimited_jids = {
    "focus@auth.meet.jitsi",
    "jvb@auth.meet.jitsi"
}

plugin_paths = { "/prosody-plugins/", "/prosody-plugins-custom", "/prosody-plugins-contrib" }

muc_mapper_domain_base = "meet.study.ilexx-tech.ru";
muc_mapper_domain_prefix = "muc";

recorder_prefixes = { "recorder@hidden.meet.jitsi" };

http_default_host = "meet.study.ilexx-tech.ru"





consider_bosh_secure = true;
consider_websocket_secure = true;


smacks_max_unacked_stanzas = 5;
smacks_hibernation_time = 60;
smacks_max_old_sessions = 1;




VirtualHost "meet.study.ilexx-tech.ru"

  
  authentication = "token"
    app_id = "<no value>"
    
    allow_empty_token = false
    
    enable_domain_verification = false
  

    ssl = {
        key = "/config/certs/meet.study.ilexx-tech.ru.key";
        certificate = "/config/certs/meet.study.ilexx-tech.ru.crt";
    }
    modules_enabled = {
        "bosh";
        
        "websocket";
        "smacks"; -- XEP-0198: Stream Management
        
        "speakerstats";
        "conference_duration";
        "room_metadata";
        
        "end_conference";
        
        
        "muc_lobby_rooms";
        
        
        "muc_breakout_rooms";
        
        
        "av_moderation";
        
        
        
        
        

    }

    main_muc = "muc.meet.jitsi"
    room_metadata_component = "metadata.meet.study.ilexx-tech.ru"
    
    lobby_muc = "lobby.meet.study.ilexx-tech.ru"
    
    

    

    
    breakout_rooms_muc = "breakout.meet.study.ilexx-tech.ru"
    

    speakerstats_component = "speakerstats.meet.study.ilexx-tech.ru"
    conference_duration_component = "conferenceduration.meet.study.ilexx-tech.ru"

    
    end_conference_component = "endconference.meet.study.ilexx-tech.ru"
    

    
    av_moderation_component = "avmoderation.meet.study.ilexx-tech.ru"
    

    c2s_require_encryption = true

    

    
VirtualHost "guest.meet.jitsi"
    authentication = "jitsi-anonymous"
    modules_enabled = {
        
        "smacks"; -- XEP-0198: Stream Management
        
        
    }
    main_muc = "muc.meet.jitsi"
    c2s_require_encryption = true
    



VirtualHost "auth.meet.jitsi"
    ssl = {
        key = "/config/certs/auth.meet.jitsi.key";
        certificate = "/config/certs/auth.meet.jitsi.crt";
    }
    modules_enabled = {
        "limits_exception";
        "smacks";
    }
    authentication = "internal_hashed"
    smacks_hibernation_time = 15;



Component "internal-muc.meet.jitsi" "muc"
    storage = "memory"
    modules_enabled = {
        "muc_hide_all";
        "muc_filter_access";
        }
    restrict_room_creation = true
    muc_filter_whitelist="auth.meet.jitsi"
    muc_room_locking = false
    muc_room_default_public_jids = true
    muc_room_cache_size = 1000
    muc_tombstones = false
    muc_room_allow_persistent = false

Component "muc.meet.jitsi" "muc"
    restrict_room_creation = true
    storage = "memory"
    modules_enabled = {
        "muc_hide_all";
        "muc_meeting_id";
        "token_verification";
        
        "polls";
        "muc_domain_mapper";
        
        "muc_password_whitelist";
        
    }

    -- The size of the cache that saves state for IP addresses
    rate_limit_cache_size = 10000;

    muc_room_cache_size = 10000
    muc_room_locking = false
    muc_room_default_public_jids = true
    
    muc_password_whitelist = {
        "focus@auth.meet.jitsi";
    }
    muc_tombstones = false
    muc_room_allow_persistent = false

Component "focus.meet.study.ilexx-tech.ru" "client_proxy"
    target_address = "focus@auth.meet.jitsi"

Component "speakerstats.meet.study.ilexx-tech.ru" "speakerstats_component"
    muc_component = "muc.meet.jitsi"

Component "conferenceduration.meet.study.ilexx-tech.ru" "conference_duration_component"
    muc_component = "muc.meet.jitsi"


Component "endconference.meet.study.ilexx-tech.ru" "end_conference"
    muc_component = "muc.meet.jitsi"



Component "avmoderation.meet.study.ilexx-tech.ru" "av_moderation_component"
    muc_component = "muc.meet.jitsi"



Component "lobby.meet.study.ilexx-tech.ru" "muc"
    storage = "memory"
    restrict_room_creation = true
    muc_tombstones = false
    muc_room_allow_persistent = false
    muc_room_cache_size = 10000
    muc_room_locking = false
    muc_room_default_public_jids = true
    modules_enabled = {
        "muc_hide_all";
    }

    


Component "breakout.meet.study.ilexx-tech.ru" "muc"
    storage = "memory"
    restrict_room_creation = true
    muc_room_cache_size = 10000
    muc_room_locking = false
    muc_room_default_public_jids = true
    muc_tombstones = false
    muc_room_allow_persistent = false
    modules_enabled = {
        "muc_hide_all";
        "muc_meeting_id";
        "polls";
        }


Component "metadata.meet.study.ilexx-tech.ru" "room_metadata_component"
    muc_component = "muc.meet.jitsi"
    breakout_rooms_component = "breakout.meet.study.ilexx-tech.ru"



