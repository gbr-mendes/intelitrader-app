<?php
interface iApiService
{
    public function __construct($api_url);
    public static function callApi($method, $url, $data);
    public function get_users();
    public function get_user_by_id($user_id);
    public function delete_user($user_id);
    public function add_user(User $user);
    public function update_user(User $user, $user_id);
}
