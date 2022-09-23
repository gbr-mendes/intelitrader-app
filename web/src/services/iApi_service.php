<?php

namespace Web\services;

interface iApi_service
{
    public function call_api($method, $data, $query_param = null);
    public function set_query_param($param);
}
