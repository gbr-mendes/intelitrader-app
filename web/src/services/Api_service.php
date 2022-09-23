<?php

namespace Web\services;

include('iApi_service.php');

use Exception;

class Api_service implements iApi_service
{
    private $api_url;

    public function __construct($api_url)
    {
        $this->api_url = $api_url;
    }
    public function call_api($method, $data, $query_param = null)
    {
        $this->set_query_param($query_param);
        $curl = curl_init();
        switch ($method) {
            case "POST":
                curl_setopt($curl, CURLOPT_POST, 1);
                if ($data)
                    curl_setopt($curl, CURLOPT_POSTFIELDS, $data);
                break;
            case "PUT":
                curl_setopt($curl, CURLOPT_CUSTOMREQUEST, "PUT");
                if ($data)
                    curl_setopt($curl, CURLOPT_POSTFIELDS, $data);
                break;
            case "DELETE":
                curl_setopt($curl, CURLOPT_CUSTOMREQUEST, "DELETE");
            default:
                if ($data)
                    $url = sprintf("%s?%s", $this->api_url, http_build_query($data));
        }
        // OPTIONS:
        curl_setopt($curl, CURLOPT_URL, $this->api_url);
        curl_setopt($curl, CURLOPT_HTTPHEADER, array(
            'Content-Type: application/json',
        ));
        curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);
        curl_setopt($curl, CURLOPT_HTTPAUTH, CURLAUTH_BASIC);
        // EXECUTE:
        $result = curl_exec($curl);
        if (!$result) {
            throw new Exception('Connection Failure');
        }
        curl_close($curl);
        return $result;
    }
    public function set_query_param($param = null)
    {
        if (!is_null($param)) {
            $this->api_url  = $this->api_url . '/' . $param;
        }
    }
}
