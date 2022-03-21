import { UserDto } from './../users/user';
export interface ArticleDto{
  id: number;
  title: string;
  content: string;
  userDto: UserDto;
}
