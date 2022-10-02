import { User } from "./User";

export interface ApiTheme {
    created_at: Date,
    posts: string[],
    subscribers: string[],
    themeName: string,
    updatedAt: Date,
    userId: User,
    __v: number
    _id: string
}