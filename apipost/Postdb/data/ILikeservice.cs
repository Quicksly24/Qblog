



using Postdb.gmodel.post;

public interface Ilike{

    public Likeobj Likepost(string likeid,string user);


    public bool unLikepost(string likeid);


    public long postcount(string postid);


}