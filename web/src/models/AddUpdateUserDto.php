<?php
class AddUpdateUserDto
{
    public string $name;
    public string $surName = "";
    public int $age;

    public function __construct($post_request)
    {

        if (empty($post_request['name'])) {
            throw new Exception('The field name is required');
        } else {
            $this->name = $post_request['name'];
        }
        if (!$post_request['age'] > 0) {
            throw new Exception('The field age must be greater than 0');
        } else {
            $this->age = $post_request['age'];
        }
        $this->surName = $post_request['surName'];
    }
}
