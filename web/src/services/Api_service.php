<?php

namespace Web\services;

use Exception;
use Web\models\User;

include('iApi_service.php');

class Api_service implements iApi_service
{
    private $api_url;

    public function __construct($api_url)
    {
        $this->api_url = $api_url;
    }
    public static function call_api($method, $url, $data)
    {
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
                    $url = sprintf("%s?%s", $url, http_build_query($data));
        }
        // OPTIONS:
        curl_setopt($curl, CURLOPT_URL, $url);
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

    public function get_users()
    {

        $data = json_decode(Api_service::call_api('GET', $this->api_url, false));
        return $data;
    }

    public function get_user_by_id($user_id)
    {

        $url = $this->api_url . '/' . $user_id;
        $data = json_decode(Api_service::call_api('GET', $url, false));
        return $data;
    }

    public function delete_user($user_id)
    {
        $url = $this->api_url . '/' . $user_id;
        $data = json_decode(Api_service::call_api("DELETE", $url, false));
        return $data;
    }

    public function add_user(User $user)
    {
        $data = json_encode($user);
        $response = Api_service::call_api('POST', $this->api_url, $data);
        return json_decode($response);
    }
    public function update_user(User $user, $user_id)
    {

        $url = $this->api_url . '/' . $user_id;
        $data = json_encode($user);
        $response = Api_service::call_api('PUT', $url, $data);
        return json_decode($response);
    }
}
